function initSmartNavbar() {
    const navbar = document.getElementById('mainNavbar');
    if (!navbar) return;

    let lastScrollTop = 0;
    const navbarHeight = navbar.offsetHeight;

    const mainContent = document.querySelector('.main');
    if (mainContent) {
        mainContent.style.marginTop = `${navbarHeight}px`;
    }

    function handleScroll() {
        const scrollTop = window.pageYOffset || document.documentElement.scrollTop;

        if (scrollTop > 50) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }

        if (scrollTop > lastScrollTop && scrollTop > navbarHeight) {
            navbar.classList.add('hidden');
        } else {
            navbar.classList.remove('hidden');
        }

        lastScrollTop = scrollTop <= 0 ? 0 : scrollTop;
    }

    window.addEventListener('scroll', handleScroll);
}

document.addEventListener('DOMContentLoaded', initSmartNavbar);