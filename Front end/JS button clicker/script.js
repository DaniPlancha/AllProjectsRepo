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

let a = (money) => {
    return new Promise((resolve, reject) => {
        if (money >= 100000) {
            resolve("You got a shit ton of money! Rich mf");
        } else if (money >= 10000) {
            resolve("You got allot of cash");
        } else {
            reject("You dont got enough");
        }
    });
}

async function doWork (money) {
    try {
        console.log("we are in the async function now. next line is await");
        let message = await a(money);
        console.log(message);
        setTimeout(() => {
            console.log("testing timeout");
        }, 2000);
    } catch (error) {
        console.log("Console's err message: " + error);
    }
}

doWork(1000000);
console.log("test async");
console.log("test async2");
console.log("test async3");

a(100).then()