document.addEventListener('DOMContentLoaded', () => {
    const scrollToTopBtn = document.getElementById('scrollToTopBtn');

    if (scrollToTopBtn) {
        // Sayfa açıldığında butonu gizli tut
        scrollToTopBtn.style.display = 'none';

        // Kaydırma olayını dinle
        window.addEventListener('scroll', () => {
            if (window.scrollY > 300) { // Sayfa 300 piksel aşağıdaysa butonu göster
                scrollToTopBtn.style.display = 'block';
            } else {
                scrollToTopBtn.style.display = 'none'; // Aksi halde gizle
            }
        });

        // Yukarı çıkma butonuna tıklama olayını dinle
        scrollToTopBtn.addEventListener('click', () => {
            window.scrollTo({
                top: 0,
                behavior: 'smooth' // Yumuşak kaydırma
            });
        });
    }
});
