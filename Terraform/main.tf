provider "azurerm" {
}

resource "azurerm_resource_group" "test" {
  name     = "acctestRG1"
  location = "East US"
}