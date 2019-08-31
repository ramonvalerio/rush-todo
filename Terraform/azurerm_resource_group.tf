# Configure the Group Resource
resource "azurerm_resource_group" "rush-group" {
  name = "rush-group-name"
  location = "East US"
}