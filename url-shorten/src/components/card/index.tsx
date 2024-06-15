import React, { ReactNode } from 'react';
import  './index.css'

interface CardProps {
    as: React.ComponentType<any>; // Accept any component type
    children: ReactNode; // Content to display within the card
}

const Card: React.FC<CardProps> = ({ as: Component, children, ...props }) => {

    return (
        <div className='card-content'>
            <Component {...props}>{children}</Component>
        </div>
    );
};

export default Card;