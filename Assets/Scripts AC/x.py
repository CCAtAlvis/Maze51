import os
num = 0
for filename in os.listdir():
	if filename.endswith(".cs"):
		num = num + sum(1 for line in open(filename))
		continue
	else:
		continue
print(num)