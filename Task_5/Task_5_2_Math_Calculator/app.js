// Dictionary of operators to avoid using the eval function 
const mathOperators = {
    '+': function (x, y) { return x + y },
    '-': function (x, y) { return x - y },
    '*': function (x, y) { return x * y },
    '/': function (x, y) { return x / y }
}

// Convert string to array of numbers and operators
function extractElements(input) {

    const numbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.']
    const operators = ['+', '-', '*', '/', '=']
    let elements = []
    let exp = ''

    const chars = input.split('')

    for (char of chars) {

        if (numbers.includes(char)) {
            exp += char
        } else if (operators.includes(char)) {            
            if (exp.length > 0) {
                const num = parseFloat(exp)
                elements.push(num)
                exp = ''
            }

            elements.push(char)
        } else {
            continue
        }
    }

    return elements
}

// Calculate answer based on prepared data
function calculateExp(elements) {
    let i = 0
    let res
    
    // Handle the first symbol
    if (elements[0] === '-') {
        res = 0 - elements[1]
        i++
    } else if (elements[0] === '+') {
        res = elements[1]
        i++
    } else {
        res = elements[0]
    }    
    
    for (i; i < elements.length; i++) {
        
        // Treat the equal sign as the end of the expression
        if (elements[i] === '=') {
            return res
        }

        if(!isFinite(elements[i])) {

            // Check negative number
            if (elements[i+1] === '-') {
                let n = parseFloat('-' + elements[i+2])
                res = mathOperators[elements[i]](res, n)
                i++
                continue
            }

            // Do an operation with the next number
            res = mathOperators[elements[i]](res, elements[i+1])
        }
    }

    return res
}

// Combine two functions together and fix the result
function processExp(input) {
    const arr = extractElements(input)
    const res = calculateExp(arr)
    return res.toFixed(2)
}


// Testing area
const inputs = [
    '1 + 2 + 3 + 4 - 5 =',
    '1*2*3*4*5=',
    '3.5 +4*10-5.3 /5 =',
    '123.44 + 44.895 * 30.645 / 33.4 - 45 + 12.04=',
    '1 + 1 - 1 - 1=',
    '0 * 0 + 0 - 0=',
    '-1        =',
    '0 =',
    '+10=',
    '2 / 0=',
    '999999999999999999999999999999 * 9=',
    '1 + some text 2=',
    '-1 -1 -1 -1=',
    '+1 + -1 + -1 +-1=',
    '5 * -1 / -3='
    
]

i = 0
for (const test of inputs) {
    var newDiv = document.createElement("div");
    newDiv.innerHTML = `<h4>Test # ${i+1}</h4><p>Expression: ${test}</p><p>Answer: ${processExp(test)}</p>`;
    var end = document.getElementById("testing")
    document.body.insertBefore(newDiv, end)

    i++    
}

