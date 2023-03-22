function onChangeCustomer() {
    const url = "Summary/GetCustomerData/";
    const customerId = document.getElementById("CustomerId").value;

    fetch(`${url}${customerId}`, {
        method: 'GET',
        headers: { 'Accept': 'application/json' }
    }).then(response => {
        response.json().then(function (data) {
            const customerCode = document.getElementById("customerCode");
            const customerEmail = document.getElementById("customerEmail");
            const finishButton = document.getElementById("finishButton");

            if (!data.success) {
                customerCode.parentElement.classList.add("invisible");
                customerEmail.parentElement.classList.add("invisible");
                finishButton.disabled = true;

                return;
            }

            customerCode.value = data.id;
            customerEmail.value = data.email;

            customerCode.parentElement.classList.remove("invisible");
            customerEmail.parentElement.classList.remove("invisible");
            finishButton.disabled = false;
        });
    })
}