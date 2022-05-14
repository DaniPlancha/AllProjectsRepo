var temp = 1;

function Add1 () {
    temp += 1;
    let a = document.getElementById("add1").innerHTML;
    document.getElementById("add1").innerHTML = Number(a) + 1;

    if (temp == 1) {
        document.getElementById("add1").style.backgroundColor = "red";
    } else if (temp == 2) {
        document.getElementById("add1").style.backgroundColor = "orange";
    } else if (temp == 3) {
        document.getElementById("add1").style.backgroundColor = "green";
    } else if (temp == 4) {
        document.getElementById("add1").style.backgroundColor = "blue";
    } else if (temp == 5) {
        document.getElementById("add1").style.backgroundColor = "indigo";
    } else {
        document.getElementById("add1").style.backgroundColor = "violet";
        temp = 0;
    }
}