#include "stdafx.h"
#include <iostream>
#include "Stack.h"

using namespace std;

Stack::Stack()
{
	top = -1;
	theArray = new int[maxInArray];
	maxInArray = 2;
}

void Stack::Push(int input) 
{
	if (top == maxInArray - 1)
	{
		cout << "The stack is full." << endl;
	}

	top++;
	theArray[top] = input;
}

void Stack::Resize()
{
	int* temporaryArray = new int[maxInArray];

	for (int i = 0; i < maxInArray; i++) 
	{
		temporaryArray[i] = theArray[i];
	}

	theArray = new int[maxInArray];

	for (int j = 0; j < maxInArray; j++) 
	{
		theArray[j] = temporaryArray[j];
	}
}

int Stack::Size() 
{
	int size = top + 1;

	return size;
}

int Stack::Pop()
{
	if (top == -1)
	{
		cout << "The stack is empty." << endl;
		return 0;
	}

	int data = theArray[top];
	top--;

	return data;
}

Stack::~Stack()
{
}