Feature: AddProduct

Add a new product

Scenario: Add new product
	Given I want to add a new product
	When I add the product with the following details
		| Name   | Price | Description              | Quantity |
		| Laptop | 5500  | A laptop with I5 8GB RAM | 10       |
	Then the product should be added successfully