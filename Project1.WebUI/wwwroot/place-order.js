'use strict';

const init = function() {
    document.createElement('btn-order').addEventListener('click', send);
}

// still need a function to multiply product price * quantity to equal line total
// after I connect to the database and have that info

function getSubotal(){
    let array = document.getElementById('linetotal');
    let subtotal = 0;
    for(let i = 0; i < array.length; i++) {
        if (parseFloat(array[i].value)) {
            subtotal += parseFloat(array[i].value);
        }
    }
    document.getElementById('subtotal').value = subtotal;
}

document.addEventListener('DOMContentLoaded', init);