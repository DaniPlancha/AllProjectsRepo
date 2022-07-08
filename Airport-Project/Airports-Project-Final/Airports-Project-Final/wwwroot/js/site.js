var GetSelectValue = () => {
    var select = document.getElementById('select-text');
    var value = select.options[select.selectedIndex].value;
    return value;
}
var GetInputValue = () => {
    return document.getElementById('input-text').value;
}

function SetAttributes() {
    document.querySelector(".input-text-search-flights-form").setAttribute("action", "/Flights/Search?inputValue=" + GetInputValue() + "&selectValue=" + GetSelectValue());
}


var GetPortId1 = () => {
    let firstFormControl = document.getElementById('form-control1');
    let secondFormControlOptions = Array.from(document.getElementById('form-control2').options);
    secondFormControlOptions.forEach(o => {
        o.hidden = false;
        o.disabled = false;
    });
    secondFormControlOptions[firstFormControl.selectedIndex].hidden = true;
    secondFormControlOptions[firstFormControl.selectedIndex].disabled = true;
}

var GetPortId2 = () => {
    let secondFormControl = document.getElementById('form-control2');
    let firstFormControlOptions = Array.from(document.getElementById('form-control1').options);
    firstFormControlOptions.forEach(o => {
        o.hidden = false;
        o.disabled = false;
    });
    firstFormControlOptions[secondFormControl.selectedIndex].hidden = true;
    firstFormControlOptions[secondFormControl.selectedIndex].disabled = true;
}


function replaceBetween(origin, startIndex, endIndex, insertion) {
    return origin.substring(0, startIndex) + insertion + origin.substring(endIndex);
}


var TimeValidate = () => {
    let currentTime = String(document.getElementById('first-date-time').value);

    let yearStart = 0;
    let yearEnd = 3;
    let monthStart = 5;
    let monthEnd = 6;
    let dayStart = 8;
    let dayEnd = 9;
    let hourStart = 11;
    let hourEnd = 12;
    /* 2022-01-31T22:mm */

    let hour = Number(currentTime.substring(hourStart, hourEnd + 1));
    let day = Number(currentTime.substring(dayStart, dayEnd + 1));
    let month = Number(currentTime.substring(monthStart, monthEnd + 1));
    let year = Number(currentTime.substring(yearStart, yearEnd + 1));

    hour = hour + 3;

    if (hour >= 24) {
        hour = hour - 24;
        currentTime = replaceBetween(currentTime, hourStart, hourEnd + 1, '0' + hour);
        day = day + 1;

        if (day == 32 && (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)) {
            day = 1;
            currentTime = replaceBetween(currentTime, dayStart, dayEnd + 1, '0' + day);
            month = month + 1;

            if (month == 13) {
                month = 1;
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, '0' + month);
                year = year + 1;
                currentTime = replaceBetween(currentTime, yearStart, yearEnd + 1, year);
            } else if (month < 10) {
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, '0' + month);
            } else {
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, month);
            }

        } else if (day == 31 && (month == 4 || month == 6 || month == 9 || month == 11)) {
            day = 1;
            currentTime = replaceBetween(currentTime, dayStart, dayEnd + 1, '0' + day);
            month = month + 1;

            if (month == 13) {
                month = 1;
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, '0' + month);
                year = year + 1;
                currentTime = replaceBetween(currentTime, yearStart, yearEnd + 1, year);
            } else if (month < 10) {
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, '0' + month);
            } else {
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, month);
            }

        } else if (day == 29 && (month == 2)) {
            day = 1;
            currentTime = replaceBetween(currentTime, dayStart, dayEnd + 1, '0' + day);
            month = month + 1;

            if (month == 13) {
                month = 1;
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, '0' + month);
                year = year + 1;
                currentTime = replaceBetween(currentTime, yearStart, yearEnd + 1, year);
            } else if (month < 10) {
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, '0' + month);
            } else {
                currentTime = replaceBetween(currentTime, monthStart, monthEnd + 1, month);
            }

        } else if (day < 10) {
            currentTime = replaceBetween(currentTime, dayStart, dayEnd + 1, '0' + day);
        } else {
            currentTime = replaceBetween(currentTime, dayStart, dayEnd + 1, day);
        }

    } else if (hour < 10) {
        currentTime = replaceBetween(currentTime, hourStart, hourEnd + 1, '0' + hour);
    } else {
        currentTime = replaceBetween(currentTime, hourStart, hourEnd + 1, hour);
    }

    document.getElementById('second-date-time').setAttribute('min', currentTime);
}