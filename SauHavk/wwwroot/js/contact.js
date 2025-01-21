// Sayfa yüklendikten sonra mesajı otomatik gizle
window.onload = function () {
    var messageDiv = document.getElementById('notificationMessage');
    if (messageDiv) {
        setTimeout(function () {
            messageDiv.style.display = 'none'; // 4 saniye sonra mesajı gizle
        }, 4000);
    }
};
