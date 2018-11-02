module "queues" {
  source = "./modules/droplets/default"
  name = "queues"
  privatekey = "${file(var.pvt_key)}"
  fingerprint = "${var.ssh_fingerprint}"
  image = "docker-18-04"
}
