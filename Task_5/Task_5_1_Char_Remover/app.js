/* Ignores in the input string all spaces, tabs and punctuation sings. 
Returns an array of words. */
function extractWords(input) {

    const separators = [' ', '?', '!', '.', ',', ';', ':', '\t', '\n', '"']
    const chars = input.split('')
    let word = ''
    let words = []

    for (let i=0; i<chars.length; i++) {       

        if (!separators.includes(chars[i])) {
            word += chars[i]
            if (i === chars.length - 1) {
                words.push(word)
                break
            }                        
        } else {
            if (word.length > 0) {
                words.push(word)
                word = ''
            }
        }
    }

    return words  
}

/* Scans each word in an array. If some letter is repeated more than once in a word, 
stores this letter in the resulting array. Returns the array of repeated letters. */
function findCharsToRemove(words) {
    
    let charsToRemove = []

    for (const word of words) {
        
        let uniqueChars = []

        for (const char of word) {
            if (!uniqueChars.includes(char)) {
                uniqueChars.push(char)
            } else {
                if (!charsToRemove.includes(char)) {
                    charsToRemove.push(char)
                }                
            }
        }
    }

    return charsToRemove    
}

/* Removes from the sentence all characters listed in the passed array. */
function deleteChars(sentence = '', chars = []) {
    
    let res = '' 

    if (chars.length < 1) {
        return sentence
    }    

    for (const letter of sentence) {
        if (chars.includes(letter)) {
            continue
        }
        else {
            res += letter
        }
    }

    return res
}

/* Combine all three functions */
function processString(input) {
    const words = extractWords(input)
    const charsToRemove = findCharsToRemove(words)
    return deleteChars(input, charsToRemove)
}


// Testing area

const inputs = [
    'Hello, World!',
    'У попа была собака',
    'У попа?,  была,собака \t! Он её любил.',
    'В кааждом слоове уудвоена оддна букква.',    
    '234 234 44 22 0',
    '!,.;:"',    
    '',
    'd',
    'aaaaa bbbbb ффффф',
    '.',
    '12345',
    ' '
]

i = 0
for (const test of inputs) {
    var newDiv = document.createElement("div");
    newDiv.innerHTML = `<h4>Test # ${i+1}</h4><p>Input: "${test}"</p><p>Output: "${processString(test)}"</p>`;
    var end = document.getElementById("testing")
    document.body.insertBefore(newDiv, end)

    const words = extractWords(test)
    const charsToRemove = findCharsToRemove(words)
    console.log('Words: ', words)
    console.log('To Remove: ', charsToRemove)
    i++    
}
