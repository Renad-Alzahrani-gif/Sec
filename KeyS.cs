using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

public class AccountController : Controller
{
    private static RSAParameters privateKey; // Load this from a secure location
    private static RSAKeyPair rsaKeyPair = new RSAKeyPair();

    static AccountController()
    {
        privateKey = rsaKeyPair.PrivateKey; // Assign private key
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        try
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(privateKey);

            // Decrypt the password
            byte[] encryptedData = Convert.FromBase64String(password);
            byte[] decryptedData = rsa.Decrypt(encryptedData, false);
            string decryptedPassword = Encoding.UTF8.GetString(decryptedData);

            // Verify credentials (example only, replace with real validation)
            if (username == "testuser" && decryptedPassword == "testpassword")
            {
                return Content("Login successful!");
            }
            else
            {
                return Content("Invalid credentials.");
            }
        }
        catch (Exception ex)
        {
            return Content("An error occurred: " + ex.Message);
        }
    }
}
