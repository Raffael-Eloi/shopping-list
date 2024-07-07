Feature: GetProduct

Get products

Scenario: Get products filtered by name
	Given A product exists with the following data
		| Name  | Price | Description         | Quantity |
		| Chair | 500   | A Confortable chair | 5        |
	And A product exists with the following data
		| Name    | Price | Description      | Quantity |
		| Headset | 600   | High end headset | 3        |
	When I get the products filtered by name "Chair"
	Then the the products should only have the filtered name
	
Scenario: Get products filtered by description
	Given A product exists with the following data
		| Name  | Price | Description         | Quantity |
		| Chair | 500   | A Confortable chair | 5        |
	And A product exists with the following data
		| Name    | Price | Description      | Quantity |
		| Headset | 600   | High end headset | 3        |
	When I get the products filtered by description "headset"
	Then the the products should only have the filtered description