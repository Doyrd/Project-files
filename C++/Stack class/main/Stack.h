#pragma once
class Stack
{

public:
	Stack();

	int maxInArray;
	int* theArray = new int[maxInArray];
	int top;
	int size;

	void Push(int input);
	void Resize();
	int Size();
	int Pop();

	~Stack();

private:


};

