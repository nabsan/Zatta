
while true;
do
  date;
  /usr/local/kafka/kafka_2.11-2.1.1/bin/kafka-console-producer.sh --broker-list localhost:9092 --topic test < /home/vagrant/bin/1000k.csv
  sleep 1s;
done
#usage loop_kafkaproduce.sh
