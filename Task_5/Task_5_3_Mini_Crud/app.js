var Service = require('./lib.js')

// Testing area

console.log('=== Storage initialization ===')
const storage = new Service()
console.log('Empty storage: ', storage)

// To store:
const user1 = {
    name: 'Max',
    age: 27,
    isAdmin: false
}
const myString = 'Hello World'
const myInt = 2020

console.log('=== Add method ===') 
storage.add(user1)
storage.add(myString)
storage.add(myInt)
storage.add(3.14)

console.log('Full storage: ', storage)

console.log('=== getById method ===') 
const a = storage.getById('id-1')
const b = storage.getById('id-100')
console.log(`Id-1: ${a}, Id-100: ${b}`)

console.log ('=== getAll method ===')
const arr = storage.getAll()
console.log("Get all items from storage: ", arr)

console.log('=== deleteById method ===')
const d = storage.deleteById('id-2')
console.log('Storage after item delition with id 2: ', storage.getAll())
console.log('Removed item: ', d)
console.log('Try to delete non-existing item: ', storage.deleteById('id-9'))

console.log('=== updateById method ===')
const newObj = {age: 32, isAdmin: true, salary: 50000}
storage.updateById('id-0', newObj)
storage.updateById('id-3', 2.17)
storage.updateById('id-100', 0) 
storage.add({A: 3, B: 5, C: 9})
console.log('Storage after updating: \n', storage)

console.log('=== replaceById method ===')
storage.replaceById('id-5', 'Replacement1')
storage.replaceById('id-1', 'Replacement2')
console.log('Storage after replacement \n', storage)