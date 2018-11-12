$token = "do_token=74e06d600605da593f0957df88ebd889f9cccda5ca3c3e3a8b0b3614917cdb21"
$pub = "pub_key=C:\Users\ethanm\.ssh\id_rsa.pub"
$pvt = "pvt_key=C:\Users\ethanm\.ssh\id_rsa"
$finger = "ssh_fingerprint=13:c8:de:23:92:f3:94:ea:69:e7:fe:06:f5:05:47:ac"

function plan(){
    terraform plan -var $token -var $pub -var $pvt -var $finger
}
function apply(){
    terraform apply -var $token -var $pub -var $pvt -var $finger
}
function destroy(){
    terraform destroy -var $token -var $pub -var $pvt -var $finger
}
function output(){
    terraform output -var $token -var $pub -var $pvt -var $finger
}