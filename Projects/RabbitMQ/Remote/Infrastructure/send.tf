module "send" {
  source = "./modules/docker"
  name = "send"
  imageName = "send"
  imageTag = "latest"
}
