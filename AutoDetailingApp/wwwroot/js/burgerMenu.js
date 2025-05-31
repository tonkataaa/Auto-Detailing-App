document.addEventListener('DOMContentLoaded', () => {
    const burger = document.getElementById('burger');
    const navList = document.querySelector('nav ul');
    const navigation = document.querySelector('.navigation');

    burger.addEventListener('click', () => {
        navList.classList.toggle('mobile-visible');
        burger.classList.toggle('active');
    });

    let lastScroll = 0;

    window.addEventListener('scroll', () => {
        const currentScroll = window.pageYOffset;

        if (currentScroll <= 0) {
            navigation.classList.remove('hidden');
            return;
        }

        if (currentScroll > lastScroll && !navigation.classList.contains('hidden')) {
            navigation.classList.add('hidden');
        } else if (currentScroll < lastScroll && navigation.classList.contains('hidden')) {
            navigation.classList.remove('hidden');
        }

        if (currentScroll > 50) {
            navigation.classList.add('scrolled');
        } else {
            navigation.classList.remove('scrolled');
        }

        lastScroll = currentScroll;
    });
});
