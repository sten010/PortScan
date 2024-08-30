document.addEventListener('DOMContentLoaded', () => {
    const ipAddressInput = document.getElementById('ip-address');
    const submitButton = document.getElementById('submit-button');
    const errorMessage = document.getElementById('error-message');



    // Обработчик нажатия на кнопку
    submitButton.addEventListener('click', () => {
        const ipAddress = ipAddressInput.value;

        console.log('IP Address:', ipAddress); // Добавлено для отладки

        if (ipAddress) {
            // Получение текущей даты и времени в формате ISO
            const now = new Date().toISOString();

            // Создание тела запроса с дополнительными параметрами
            const requestBody = {
                ipAdress: ipAddress,
                dateScan: now,
                port: '' // Пустая строка
            };

            fetch('http://localhost:5043/api/Scanings', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(requestBody)
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Сетевая ошибка.');
                    }
                    return response.json();
                })
                .then(data => {
                    console.log('Результат:', data);
                    window.location.reload(); // Обновляем страницу
                })
                .catch(error => {
                    console.error('Ошибка:', error);
                    errorMessage.textContent = 'Произошла ошибка при отправке данных.';
                });
        }
    });
});