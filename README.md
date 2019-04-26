# RabbitMQ Example
This is a simple RabbitMQ example. Please follow the steps to run this example

## Steps
- Install docker on your local machine (if required).
- Run RabbitMQ as docker container:
	> docker run -d --hostname my-rabbit --name some-rabbit -p 4369:4369 -p 5671:5671 -p 5672:5672 -p 15672:15672 rabbitmq
- Enable RabbitMQ management plugin:
	> docker exec some-rabbit rabbitmq-plugins enable rabbitmq_management
- Login at http://localhost:15672/ (or the IP of your docker host):
	> using guest/guest
- Run one instance of RabbitMQReceiver and more than one instances of RabbitMQSender and follow the instructions on the console. 
