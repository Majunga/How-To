output "Public ip" {
  value = "${digitalocean_droplet.default.ipv4_address}"
}