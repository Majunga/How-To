module "queues" {
  source = "./modules/docker"
  name = "queues"
  imageName = "rabbitmq"
  imageTag = "management"
}
