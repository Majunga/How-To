module "send" {
  source = "./modules/droplets/default"
  name = "send"
  privatekey = "${file(var.pvt_key)}"
  fingerprint = "${var.ssh_fingerprint}"
  image = "docker-18-04"
}
