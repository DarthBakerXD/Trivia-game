import socket
import umsgpack

SERVER_IP = "127.0.0.1"
SERVER_PORT = 5656

outgoing_json = {"username": input("Enter Username: "), "password": input("Enter Password: ")}
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((SERVER_IP, SERVER_PORT))

output = b"101" + umsgpack.packb(outgoing_json)

sock.send(output)
print("waiting for response")
response = sock.recv(1024)
print(umsgpack.unpackb(response[3:]))

outgoing_json = {"id": int(input("Enter Room ID: "))}
output = b"113" + umsgpack.packb(outgoing_json)
sock.send(output)
print("waiting for response")
response = sock.recv(1024)
print(umsgpack.unpackb(response[3:]))
output = b"111"
sock.send(output)
print("waiting for response")
response = sock.recv(1024)
print(umsgpack.unpackb(response[3:]))