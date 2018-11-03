module "recieve" {
  source = "./modules/docker"
  name = "recieve"
  imageName = "send"
  imageTag = "latest"
}
