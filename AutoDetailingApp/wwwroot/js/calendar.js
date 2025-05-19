document.addEventListener('DOMContentLoaded', function () {
    const dateInput = document.querySelector('input[type="datetime-local"]');

    const now = new Date();
    const minDate = now.toISOString().slice(0, 16);
    dateInput.min = minDate;

    const minutes = now.getMinutes();
    now.setMinutes(minutes < 30 ? 30 : 60);
    const initialDate = now.toISOString().slice(0, 16);
    dateInput.value = initialDate;

    dateInput.addEventListener('input', function () {
        const value = new Date(this.value);
        const minutes = value.getMinutes();
        value.setMinutes(minutes < 30 ? 30 : 0);
        this.value = value.toISOString().slice(0, 16);
    });
});