# Configure the AKS (Azure Kubernetes Cluster) Resource
resource "azurerm_kubernetes_cluster" "aks" {
  name                = "rush-aks-name"
  location            = "${azurerm_resource_group.rush-group.location}"
  resource_group_name = "${azurerm_resource_group.rush-group.name}"
  dns_prefix          = "rush-aks-dns"

  agent_pool_profile {
    name            = "default"
    count           = 1
    vm_size         = "Standard_D1_v2"
    os_type         = "Linux"
    os_disk_size_gb = 30
  }

  agent_pool_profile {
    name            = "pool2"
    count           = 1
    vm_size         = "Standard_D2_v2"
    os_type         = "Linux"
    os_disk_size_gb = 30
  }

  service_principal {
    client_id     = "ce0dfadd-c8c7-4791-8561-3b6e8617c3f1"
    client_secret = "1g0UlJGGD3y4VCH@P_AeI+v*ypkDiJj9"
  }

  tags = {
    Environment = "Production"
  }
}

output "client_certificate" {
  value = "${azurerm_kubernetes_cluster.aks.kube_config.0.client_certificate}"
}

output "kube_config" {
  value = "${azurerm_kubernetes_cluster.aks.kube_config_raw}"
}