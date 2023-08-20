
document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector("form");

    form.addEventListener("submit", function(event) {
        let isValid = true;
        const nameField = document.getElementById("Name");
       
        // Validate that name is not empty
        if (!nameField.value.trim()) {
            alert("Name is required.");
            isValid = false;
        }

        if (!isValid) {
            event.preventDefault();
        }
    });
});
