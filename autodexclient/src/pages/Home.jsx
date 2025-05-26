import React, { useState, useEffect } from "react";
import CarCard from "../components/vehicleCard/carCard/CarCard";
// import MotorcycleCard from "../components/MotorcycleCard"; // futuro

import "./Home.css";

export default function Home() {
  const [id, setId] = useState("");
  const [type, setType] = useState("Cars"); // tipo do veículo selecionado
  const [result, setResult] = useState(null);
  const [error, setError] = useState("");

  const apiBase = "http://localhost:5125";

  useEffect(() => {
    setResult(null);
    setError("");
    setId(""); // opcional: remove o valor do input
  }, [type]);

  const handleSearch = async () => {
    setError("");
    setResult(null);

    try {
      // Se nenhum ID, buscar todos do tipo selecionado
      if (!id.trim()) {
        const res = await fetch(`${apiBase}/${type}`);
        if (!res.ok) {
          throw new Error(`Failed to fetch all ${type}`);
        }
        const data = await res.json();
        setResult({ type: "All", data });
        return;
      }

      // Buscar pelo ID
      const res = await fetch(`${apiBase}/${type}/${id}`);
      if (res.ok) {
        const data = await res.json();
        setResult({ type: type.slice(0, -1), data }); // remove o "s"
      } else {
        setError(`No ${type.slice(0, -1)} found with that ID.`);
      }
    } catch (e) {
      console.error(e);
      setError("Network error.");
    }
  };

  const handleEdit = (vehicle) => {
    console.log("Edit", vehicle);
    // Pode abrir um modal futuramente
  };

  const handleDelete = async (vehicleId) => {
    if (!result) return;

    const endpoint =
      result.type === "Car"
        ? `${apiBase}/Cars/${vehicleId}`
        : `${apiBase}/Motorcycles/${vehicleId}`;

    try {
      const res = await fetch(endpoint, { method: "DELETE" });

      if (res.ok) {
        alert(`${result.type} deleted successfully.`);
        setResult(null);
        setId("");
      } else {
        alert(`Failed to delete ${result.type}.`);
      }
    } catch (error) {
      console.error(error);
      alert("Network error while deleting.");
    }
  };

  return (
    <div className="home-container">
      <h1>Auto Dex</h1>

      <div className="search-bar">
        <select className="option" value={type} onChange={(e) => setType(e.target.value)}>
          <option value="Cars">Cars</option>
          <option value="Motorcycles">Motorcycles</option>
        </select>
        <input
          type="text"
          placeholder="Enter vehicle ID"
          value={id}
          onChange={(e) => setId(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>

      {error && <p className="error">{error}</p>}

      {result && (
        <div className="result">
          {result.type === "Car" && (
            <div className="vehicles-list">
              <CarCard
                car={result.data}
                onEdit={handleEdit}
                onDelete={handleDelete}
              />
            </div>
          )}

          {result.type === "Motorcycle" && (
            <p>
              Aqui entraria o <code>MotorcycleCard</code> no futuro.
            </p>
            // <MotorcycleCard
            //   motorcycle={result.data}
            //   onEdit={handleEdit}
            //   onDelete={handleDelete}
            // />
          )}

          {result.type === "All" && (
            <div className="vehicles-list">
              {type === "Cars" &&
                result.data.map((car) => (
                  <CarCard
                    key={car.id}
                    car={car}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                  />
                ))}

              {type === "Motorcycles" &&
                result.data.map((moto) => (
                  <div key={moto.id} className="motorcycle-card">
                    <p><strong>{moto.name}</strong> - {moto.mark}</p>
                    {/* Substituir futuramente por <MotorcycleCard ... /> */}
                  </div>
                ))}
            </div>
          )}
        </div>
      )}
    </div>
  );
}
