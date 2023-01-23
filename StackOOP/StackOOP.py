class Stack:

	def __init__(self):
		self.__Elements = 10
		self.__StackPtr = 0
		self.__Stack = [None for _ in range(self.__Elements)]

	def IsEmpty(self):
		return self.__StackPtr == 0

	def IsFull(self):
		return self.__StackPtr == self.__Elements

	def Push(self,n):
		if not self.IsFull():
			self.__Stack[self.__StackPtr] = n
			self.__StackPtr += 1
		else:
			print("Stack Overflow")

	def Pop(self):
		if not self.IsEmpty():
			self.__StackPtr -= 1
			return self.__Stack[self.__StackPtr ]
		else:
			print("Stack Overflow")

	def Peek(self):
		if not IsEmpty(self):
			return self.__Stack[self.__StackPtr]

	def Display(self):
		print(self.__Stack)
		print(self.__StackPtr)


myStack = Stack()

for i in range(3):
	v = input("Enter val: ")
	myStack.Push(v)

while not myStack.IsEmpty():
	print(myStack.Pop())

