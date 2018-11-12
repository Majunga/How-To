resource "digitalocean_droplet" "default" {
  name               = "${var.name}" # name var
  image              = "${var.image}"
  region             = "lon1"
  size               = "s-1vcpu-1gb"
  private_networking = true

  ssh_keys = [
    "${var.fingerprint}", # ssh fingerprint var
  ]

  connection {
    user        = "root"
    type        = "ssh"
    private_key = "${var.privatekey}" # Private key var
    timeout     = "2m"
  }

    provisioner "remote-exec" {
    inline = [
      "export PATH=$PATH:/usr/bin",
      "wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb",
      "sudo dpkg -i packages-microsoft-prod.deb",
      "sudo apt-get update",
      "sudo apt-get install -y powershell",

    ]
  }
}