import React from 'react';
import './CarCard.css'; // caso queira estilização externa

const CarCard = ({ car, onEdit, onDelete }) => {
  return (
    <div className="car-card">
      <img
        src={
          car.imageUrl && car.imageUrl.startsWith("http")
            ? car.imageUrl
            : "https://via.placeholder.com/300x200.png?text=No+Image"
        }
        alt={car.name}
        className="car-image"
      />
      <h2>{car.name}</h2>
      <p><strong>Mark:</strong> {car.mark}</p>
      <p><strong>Year:</strong> {car.yearManufacture}</p>
      <p><strong>Type:</strong> {car.type}</p>
      <p><strong>Doors:</strong> {car.doors}</p>
      <p><strong>Traction:</strong> {car.traction}</p>
      <div className="button-group">
        <button className="edit-btn" onClick={() => onEdit(car)}>Edit</button>
        <button className="delete-btn" onClick={() => onDelete(car.id)}>Delete</button>
      </div>
    </div>
  );
};

export default CarCard;
