function validateOnSubmit() {
    var currentUrlField = document.getElementsByClassName("currentUrl");
    const requiredFields = document.querySelectorAll('[required]');

    var isEmpty = true;

    if (currentUrlField) {
        for (var i = 0; i < currentUrlField.length; i++) {
            currentUrlField[i].value = window.location.href;
        }        
    }

    for (var i = 0; i < requiredFields.length; i++) {

        if (requiredFields[i].value.trim() === '') {
            var aspForValue = requiredFields[i].getAttribute("data-asp-for");
            var validationSpan = document.querySelector('span[data-asp-validation-for="' + aspForValue + '"]');

            console.log("asp" + aspForValue);

            validationSpan.innerText = `This field is required ${aspForValue}`;

            console.log("2");

        }

    }

    var spanTags = document.getElementsByClassName("error");

    for (var i = 0; i < spanTags.length; i++) {

        if (spanTags[i].textContent.trim() !== "") {
            isEmpty = false;
        }

        if (!isEmpty) {
            return false;
        }
    }

    return true;
}


function validateForm(event, errorMsgId, label) {
    var errorMsgElement = document.getElementById(errorMsgId);
    var element = event.target;
    errorMsgElement.innerText = "";

    if (element.value && element.required === "") {
        errorMsgElement.innerText = `This field is required`;
    }


    switch (label) {
        //contact cases
        case 'contactName':
            validateName(element, errorMsgElement, label);
            break;
        case 'contactEmail':
            validateEmail(element, errorMsgElement, label);
            break;
        case 'contactPhoneNumber':
            validatePhoneNumber(element, errorMsgElement, label);
            break;
        case 'contactMessage':
            validateFreeText(element, errorMsgElement, label);
            break;
    }
}

//Modules
function validateName(element, errorMsgElement, label) {
    const NameRegEx = /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/;

    if (element.value.length < 2) {
        errorMsgElement.innerText = `Your name must contain at least 2 characters!`;
    }
    else if (!NameRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid name.`;
    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateEmail(element, errorMsgElement, label) {
    const emailRegEx = /^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$/;

    if (!emailRegEx.test(element.value)) {
        errorMsgElement.innerText = `Please enter a valid email. (ex: test@domain.se)`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}

function validateFreeText(element, errorMsgElement, label) {
    if (element.value.length < 2) {
        errorMsgElement.innerText = `Your message must contain at least 2 characters!`;

    }
    else {
        errorMsgElement.innerText = "";
    }
}
