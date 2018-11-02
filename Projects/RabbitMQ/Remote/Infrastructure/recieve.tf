module "recieve" {
  source = "./modules/droplets/default"
  name = "recieve"
  privatekey = "${file(var.pvt_key)}"
  fingerprint = "${var.ssh_fingerprint}"
  image = "docker-18-04"
}
