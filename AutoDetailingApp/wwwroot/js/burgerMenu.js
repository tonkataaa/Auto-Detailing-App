document.addEventListener('DOMContentLoaded', () => {
    const burger = document.getElementById('burger');
    const navList = document.getElementById('navLinks');
    const navigation = document.querySelector('.navigation');
    const navActions = document.querySelector('.nav-actions');

    burger.addEventListener('click', () => {
        navList.classList.toggle('mobile-visible');
        if (navActions) navActions.classList.toggle('mobile-visible');
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
            navList.classList.remove('mobile-visible');
            if (navActions) navActions.classList.remove('mobile-visible');
            burger.classList.remove('active');
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
