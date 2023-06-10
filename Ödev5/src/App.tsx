import React, { useState } from 'react';
import { Container, Header, Input, Button, List } from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css';
import './App.css';

interface Todo {
    id: number;
    task: string;
    isCompleted: boolean;
    createdDate: Date;
}

function App() {
    const [todos, setTodos] = useState<Todo[]>([]);
    const [inputValue, setInputValue] = useState('');

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleAddTodo = () => {
        if (inputValue !== '') {
            const newTodo: Todo = {
                id: todos.length + 1,
                task: inputValue,
                isCompleted: false,
                createdDate: new Date(),
            };
            setTodos([...todos, newTodo].sort((a, b) => a.createdDate.getTime() - b.createdDate.getTime()));
            setInputValue('');
        }
    };

    const handleDeleteTodo = (id: number) => {
        const newTodos = todos.filter(todo => todo.id !== id);
        setTodos(newTodos);
    };

    const handleToggleComplete = (id: number) => {
        const newTodos = [...todos];
        const todoIndex = newTodos.findIndex(todo => todo.id === id);
        if (todoIndex !== -1) {
            newTodos[todoIndex].isCompleted = !newTodos[todoIndex].isCompleted;
            setTodos(newTodos);
        }
    };

    return (
        <Container textAlign="justified" >
            <Header as="h1" attached="top">Todos</Header>
            <Input 
                placeholder="New Todo..."
                value={inputValue}
                onChange={handleInputChange}
            />
            <Button attached="right" primary onClick={handleAddTodo}>Add</Button>
            <List divided relaxed >
                {todos.map((todo) => (
                    <List.Item key={todo.id}>
                        <List.Content floated="right">
                            <Button
                                icon="delete"
                                negative
                                onClick={() => handleDeleteTodo(todo.id)}
                            />
                        </List.Content>
                        <List.Content
                            className={todo.isCompleted ? 'completed' : ''}
                            onClick={() => handleToggleComplete(todo.id)}
                        >
                            {todo.task}
                        </List.Content>
                        <List.Content floated="right">
                            Created: {todo.createdDate.toLocaleString()}
                        </List.Content>
                    </List.Item>
                ))}
            </List>
        </Container>
    );
}

export default App;
