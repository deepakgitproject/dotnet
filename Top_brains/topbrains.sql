-
create database topbrains;
go
use topbrains;
go
use lpu
drop database topbrains




create table Customer (
    CustomerID int identity(1,1) primary key,
    CustomerName varchar(100),
    CustomerPhone varchar(20),
    CustomerCity varchar(50)
);


create table SalesPerson (
    SalesPersonID int identity(1,1) primary key,
    SalesPersonName varchar(100)
);


create table Product (
    ProductID int identity(1,1) primary key,
    ProductName varchar(100),
    Price decimal(10,2)
);


create table Orders (
    OrderID int identity(1,1) primary key,
    OrderDate date,
    CustomerID int,
    SalesPersonID int,
    foreign key (CustomerID) references Customer(CustomerID),
    foreign key (SalesPersonID) references SalesPerson(SalesPersonID)
);


create table OrderItems (
    OrderItemID int identity(1,1) primary key,
    OrderID int,
    ProductID int,
    Quantity int,
    foreign key (OrderID) references Orders(OrderID),
    foreign key (ProductID) references Product(ProductID),
    unique (OrderID, ProductID)
);




insert into SalesPerson (SalesPersonName) values ('Anitha');
insert into SalesPerson (SalesPersonName) values ('Suresh');



insert into Customer (CustomerName, CustomerPhone, CustomerCity)
values ('Ravi Kumar', '9876543210', 'Chennai');

insert into Customer (CustomerName, CustomerPhone, CustomerCity)
values ('Priya Sharma', '9123456789', 'Bangalore');

insert into Customer (CustomerName, CustomerPhone, CustomerCity)
values ('John Peter', '9988776655', 'Hyderabad');

update Customer set CustomerName = 'Mari' where CustomerName = 'John Peter'



insert into Product (ProductName, Price) values ('Laptop', 55000);
insert into Product (ProductName, Price) values ('Mouse', 500);
insert into Product (ProductName, Price) values ('Keyboard', 1500);
insert into Product (ProductName, Price) values ('Monitor', 12000);


insert into Orders (OrderDate, CustomerID, SalesPersonID)
values ('2024-01-05', 1, 1);

insert into Orders (OrderDate, CustomerID, SalesPersonID)
values ('2024-01-06', 2, 1);

insert into Orders (OrderDate, CustomerID, SalesPersonID)
values ('2024-01-10', 1, 2);

insert into Orders (OrderDate, CustomerID, SalesPersonID)
values ('2024-02-01', 3, 1);

insert into Orders (OrderDate, CustomerID, SalesPersonID)
values ('2024-02-10', 2, 2);



insert into OrderItems (OrderID, ProductID, Quantity) values (1, 1, 1);
insert into OrderItems (OrderID, ProductID, Quantity) values (1, 2, 2);

insert into OrderItems (OrderID, ProductID, Quantity) values (2, 3, 1);
insert into OrderItems (OrderID, ProductID, Quantity) values (2, 2, 1);

insert into OrderItems (OrderID, ProductID, Quantity) values (3, 1, 1);

insert into OrderItems (OrderID, ProductID, Quantity) values (4, 4, 1);
insert into OrderItems (OrderID, ProductID, Quantity) values (4, 2, 1);

insert into OrderItems (OrderID, ProductID, Quantity) values (5, 1, 1);
insert into OrderItems (OrderID, ProductID, Quantity) values (5, 3, 1);

----1

select 
    o.OrderID,
    o.OrderDate,
    c.CustomerName,
    p.ProductName,
    oi.Quantity,
    p.Price
from Orders o
join Customer c on o.CustomerID = c.CustomerID
join OrderItems oi on o.OrderID = oi.OrderID
join Product p on oi.ProductID = p.ProductID
order by o.OrderID;


------2

WITH OrderTotals AS (
    SELECT
        o.OrderID,
        SUM(oi.Quantity * p.Price) AS TotalSales
    FROM Orders o
    JOIN OrderItems oi ON o.OrderID = oi.OrderID
    JOIN Product p ON oi.ProductID = p.ProductID
    GROUP BY o.OrderID
)
select  * from OrderTotals order by TotalSales DESC
    OFFSET 2 Rows fetch next 1 row only;









----3

select
    sp.SalesPersonName,
    sum(oi.Quantity * p.Price) as TotalSales
from SalesPerson sp
join Orders o
    on sp.SalesPersonID = o.SalesPersonID
join OrderItems oi
    on o.OrderID = oi.OrderID
join Product p
    on oi.ProductID = p.ProductID
group by sp.SalesPersonName
having sum(oi.Quantity * p.Price) > 60000;


---5

select
    upper(c.CustomerName) as CustomerName,
    month(o.OrderDate) as OrderMonth,
    o.OrderID,
    o.OrderDate
from Orders o
join Customer c
    on o.CustomerID = c.CustomerID
where year(o.OrderDate) = 2024
  and month(o.OrderDate) = 1;

