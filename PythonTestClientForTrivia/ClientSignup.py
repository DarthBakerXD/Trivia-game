import socket
import struct

SERVER_IP = "127.0.0.1"
SERVER_PORT = 5656

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((SERVER_IP, SERVER_PORT))
outgoing_json = {"username": "Ron", "password": "123456", "email": "ron@mail.com"}
uint8_arr = [223, 0, 0, 0, 3, 168, 117, 115, 101, 114, 110, 97, 109, 101, 163, 82, 111, 110, 168, 112,
             97, 115, 115, 119, 111, 114, 100, 166, 49, 50, 51, 52, 53, 54, 165, 101, 109, 97, 105, 108,
             172, 114, 111, 110, 64, 109, 97, 105, 108, 46, 99, 111, 109]
output = b""
for x in uint8_arr:
    x = x - 256 if x > 127 else x
    output += struct.pack('b', x)
output = b"102" + output
print(output)
print(len(output))
sock.send(output)
print("waiting for response")
response = sock.recv(1024)
print(response)
new_arr = []
for x in response[3:]:
    new_arr.append(x)

print(new_arr)
