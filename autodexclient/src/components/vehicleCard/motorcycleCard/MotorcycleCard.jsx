import React from 'react';
import './MotorcycleCard.css';

const MotorcycleCard = ({ motorcycle, onEdit, onDelete }) => {
  return (
    <div className="motorcycle-card">
      <img
        src={
          motorcycle.imageUrl && motorcycle.imageUrl.startsWith("http")
            ? motorcycle.imageUrl
            : "https://via.placeholder.com/300x200.png?text=No+Image"
        }
        alt={motorcycle.name}
        className="motorcycle-image"
      />

      <h2 className="motorcycle-title">{motorcycle.name}</h2>
      
      <p className="motorcycle-text"><strong>Marca:</strong> {motorcycle.mark}</p>
      <p className="motorcycle-text"><strong>Ano:</strong> {motorcycle.yearManufacture}</p>
      <p className="motorcycle-text"><strong>Tipo:</strong> {motorcycle.type}</p>
      <p className="motorcycle-text"><strong>Cilindradas:</strong> {motorcycle.engineDisplacement} cc</p>
      <p className="motorcycle-text"><strong>Tipo de Guidão:</strong> {motorcycle.typeHandlebar}</p>
      <p className="motorcycle-text"><strong>Tipo de Freio:</strong> {motorcycle.brakeType}</p>

      <div className="motorcycle-buttons">
        <button className="motorcycle-btn edit" onClick={() => onEdit(motorcycle)}>Editar</button>
        <button className="motorcycle-btn delete" onClick={() => onDelete(motorcycle.id)}>Excluir</button>
      </div>
    </div>
  );
};

export default MotorcycleCard;