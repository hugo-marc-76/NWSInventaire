var startDate = document.getElementById('startDatePicker')
var endDate = document.getElementById('endDate')


endDate.addEventListener('change', (e) => {
    var endDateVal = e.target.value
    if (startDate.value > endDateVal) {
        endDate.value = "";
        document.getElementById('endDateSelected').innerText = "Entrez une date supérieur à celle de départ"
    }
}) 