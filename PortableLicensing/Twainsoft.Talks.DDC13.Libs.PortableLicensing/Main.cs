using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Portable.Licensing;
using Portable.Licensing.Validation;

namespace Twainsoft.Talks.DDC13.Libs.PortableLicensing
{
    public partial class Main : Form
    {
        private string PrivateKey { get; set; }
        private string PublicKey { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void createKeys_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(password.Text))
            {
                var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
                var keyPair = keyGenerator.GenerateKeyPair();
                PrivateKey = keyPair.ToEncryptedPrivateKeyString(password.Text.Trim());
                PublicKey = keyPair.ToPublicKeyString();

                MessageBox.Show("Keys created!");
            }
        }

        private void createLicense_Click(object sender, System.EventArgs e)
        {
            var license = License.New()
                                 .WithUniqueIdentifier(Guid.NewGuid())
                                 .As(LicenseType.Trial)
                                 .ExpiresAt(DateTime.Now.AddDays(30))
                                 .WithMaximumUtilization(5)
                                 .WithProductFeatures(new Dictionary<string, string>()
                                     {
                                         {"Sales", sales.Checked.ToString()},
                                         {"Billing", billing.Checked.ToString()},
                                         {"Users", users.Text.Trim()}
                                     })
                                 .WithAdditionalAttributes(new Dictionary<string, string>()
                                     {
                                         {attributeName.Text.Trim(), attributeValue.Text.Trim()}
                                     })
                                 .LicensedTo(customer.Text.Trim(), email.Text.Trim())
                                 .CreateAndSignWithPrivateKey(PrivateKey, password.Text.Trim());

            File.WriteAllText("License.lic", license.ToString(), Encoding.UTF8);

            MessageBox.Show("License file saved!");
        }

        private void loadLicense_Click(object sender, EventArgs e)
        {
            License license;
            using (var streamReader = new StreamReader("License.lic"))
            {
                license = License.Load(streamReader);
            }

            var validationFailures = license.Validate()
                                            .ExpirationDate()
                                            .When(lic => lic.Type == LicenseType.Trial)
                                            .And()
                                            .Signature(PublicKey)
                                            .AssertValidLicense();

            validationErrors.Clear();

            var enumerable = validationFailures as IValidationFailure[] ?? validationFailures.ToArray();
            foreach (var validationFailure in enumerable)
            {
                validationErrors.Text += validationFailure.Message + ": " + validationFailure.HowToResolve + "\n";
            }

            if (!enumerable.Any())
            {
                validationErrors.Text = "No errors detected!";

                licensedCustomer.Text = license.Customer.Name;
                licensedEMail.Text = license.Customer.Email;
                licensedSales.Checked = Convert.ToBoolean(license.ProductFeatures.Get("Sales"));
                licensedBilling.Checked = Convert.ToBoolean(license.ProductFeatures.Get("Billing"));
                licensedMaxUsers.Text = license.ProductFeatures.Get("Users");
                licensedCustomAttributeValue.Text = license.AdditionalAttributes.Get(attributeName.Text.Trim());
            }

            MessageBox.Show("License file loaded!");
        }
    }
}
