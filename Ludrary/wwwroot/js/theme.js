function createParticles() {
    const particlesContainer = document.getElementById('particles');
    if (!particlesContainer) return;

    const particleCount = 100;

    for (let i = 0; i < particleCount; i++) {
        const particle = document.createElement('div');
        particle.className = 'particle';

        const posX = Math.random() * 100;
        const posY = Math.random() * 100;
        const size = Math.random() * 3 + 1;
        const duration = Math.random() * 10 + 5;
        const delay = Math.random() * 5;

        particle.style.left = `${posX}%`;
        particle.style.top = `${posY}%`;
        particle.style.width = `${size}px`;
        particle.style.height = `${size}px`;
        particle.style.animation = `float ${duration}s ${delay}s infinite ease-in-out`;

        particlesContainer.appendChild(particle);
    }
}

function initializeHeaderScrollEffect() {
    window.addEventListener('scroll', function () {
        const header = document.querySelector('header');
        if (window.scrollY > 50) {
            header.style.padding = '12px 50px';
            header.style.boxShadow = '0 10px 30px rgba(0, 0, 0, 0.4)';
        } else {
            header.style.padding = '20px 50px';
            header.style.boxShadow = 'none';
        }
    });
}