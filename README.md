

In this assignment, you will create a simple inventory management system which allows users to add, remove, and view items in the inventory.

$${\color{green} \large   Inventory \space Management \space 🔝 \space 🎯 }$$
-

##  Level 1 - *Mandatory*
- [x] ~~Create `class Item`, which has name (readonly), quantity, and created date, which are private. Amount of each item cannot be negative. Provide the following features:~~
- [x] ~~`Contructor` to take parameters of name, quantity, and created date (optional, if not set, it will be current date).~~
- [x] ~~Create `class Store` with the following properties and methods:~~
- [x] ~~A collection to store items, which is private. Initially, this will be an empty collection.~~
- [x] ~~`Methods to add/delete one item` to the collection. Do not allow to add items with same name to the store~~
- [x] ~~`Method GetCurrentVolume` to compute the total amount of items in the store~~
- [x] ~~`Method FindItemByName` to find an item by name.~~
- [x] ~~`Method SortByNameAscto` get the sorted collection by name in ascending order.~~

 >  [!NOTE] 
 > You do not need to follow exactly the same

### items example 
<details><summary>Details 👩🏻‍💻 </summary>
<p>

```c#
var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
var coffee = new Item("Coffee", 20);
var sandwich = new Item("Sandwich", 15);
var batteries = new Item("Batteries", 10);
var umbrella = new Item("Umbrella", 5);
var sunscreen = new Item("Sunscreen", 8);
```

</p>
</details> 
<hr />

## Level 2 - *Extra feature: Capacity*
`Class Store` should have the following features:
- [x] ~~Maximum capacity , which is total amount of items allowed in the store, and contructor should also take an integer value as the maximum capacity of the inventory.~~
- [x] ~~Modify the add method to not overload the capacity~~

<hr />

## Level 3 - *Extra feature: Complex functionalities*
`Class Store` should have extra features
- [x] ~~`Method SortByDate` to get the sorted collection by date dynamically (asc or desc)~~

###  items example
<details><summary>Details 👩🏻‍💻 </summary>
<p>

```c#
 // method invocation example - You do not need to follow exactly the same
`var store = new Store(300)`
// ... add all items to the store
`var collectionSortedByDate = store.SortByDate(SortOrder.DESC)`
// print all items
...
```
</p>
</details> 

- [x] ~~`Method GroupByDate` to return 2 groups New Arrival and Old items. New Arrival items are those created within the last three months. For example, if the current month is October, then items created in August, September, and October are categorized as New Arrival. Items created before August are categorized as Old.~~

###  items example
<details><summary>Details 👩🏻‍💻 </summary>
<p>


```ruby
// method invocation example - You do not need to follow exactly the same
 var store = new Store(300);

//... add all items to the store
var groupByDate = store.GroupByDate();
foreach (var group in groupByDate) {
    Console.WriteLine($"{group.Key} Items:");
    foreach (var item in group.Value) {
        Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
    }
}
```
```c#
//Expected outcome
New Arrival Items:
 - Coffee, Created: [current date]
 - Sandwich, Created: [current date]
 - Batteries, Created: [current date]
 - Umbrella, Created: [current date]
 - Sunscreen, Created: [current date]

Old Items:
 - Water Bottle, Created: 01/01/2023
 - Chocolate Bar, Created: 02/01/2023
 - Notebook, Created: 03/01/2023
 - Pen, Created: 04/01/2023
 - Tissue Pack, Created: 05/01/2023
 - Chips Bag, Created: 06/01/2023
 - Soda Can, Created: 07/01/2023
 - Soap, Created: 08/01/2023
 - Shampoo, Created: 09/01/2023
 - Toothbrush, Created: 10/01/2023
```

</p>
</details> 

