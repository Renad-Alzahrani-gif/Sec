// Public key provided by the server
const publicKey = `
-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA...
-----END PUBLIC KEY-----
`;

document.getElementById("Log in-form").addEventListener("submit", function (e) {
    e.preventDefault();

    const passwordField = document.getElementById("password");
    const encrypt = new JSEncrypt();
    encrypt.setPublicKey(publicKey);

    const encryptedPassword = encrypt.encrypt(passwordField.value);

    if (encryptedPassword) {
        passwordField.value = encryptedPassword;
        console.log("Encrypted Password:", encryptedPassword);
        this.submit(); // Submit the form after encryption
    } else {
        alert("Encryption failed. Please try again.");
    }
});