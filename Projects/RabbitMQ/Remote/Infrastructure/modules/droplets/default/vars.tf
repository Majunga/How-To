variable "do_token" {
  description = "DigitalOcean Token"
}

variable "name" {
  description = "Name of the droplet"
}

variable "image" {
  description = "Image Slug to use (see images.json)"
}

variable "fingerprint" {
  description = "SSH Fingerprint"
}

variable "privatekey" {
  description = "Private key file"
}

