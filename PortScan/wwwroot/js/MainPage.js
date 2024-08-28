document.addEventListener('DOMContentLoaded', () => {
    const ipInput = document.getElementById('ip-address');
    const errorMessage = document.getElementById('error-message');
    const submitButton = document.getElementById('submit-button');

    ipInput.addEventListener('input', () => {
        const value = ipInput.value;
        const isValid = validateIP(value);

        if (isValid) {
            errorMessage.textContent = '';
            ipInput.style.borderColor = 'green';
            submitButton.disabled = false;
        } else {
            errorMessage.textContent = 'Неправильный адрес';
            ipInput.style.borderColor = 'red';
            submitButton.disabled = true;
        }
    });

    function validateIP(ip) {
        // Regular expression to validate IPv4 address
        const regex = /^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/;
        return regex.test(ip);
    }
});