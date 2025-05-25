// src/pages/Home.jsx
import React, { useState } from "react";
import "./Home.css";

export default function Home() {
  const [id, setId] = useState("");
  const [result, setResult] = useState(null);
  const [error, setError] = useState("");

  const apiBase = "http://localhost:5125";

  const handleSearch = async () => {
    setError("");
    setResult(null);

    if (!id.trim()) {
      setError("Please enter an ID.");
      return;
    }

    try {
      // tenta Cars
      let res = await fetch(`${apiBase}/Cars/${id}`);
      if (res.ok) {
        const car = await res.json();
        setResult({ type: "Car", data: car });
        return;
      }
      // tenta Motorcycles
      res = await fetch(`${apiBase}/Motorcycles/${id}`);
      if (res.ok) {
        const moto = await res.json();
        setResult({ type: "Motorcycle", data: moto });
        return;
      }
      setError("No Car or Motorcycle found with that ID.");
    } catch (e) {
      console.error(e);
      setError("Network error.");
    }
  };

  return (
    <div className="home-container">
      <h1>Auto Dex</h1>

      <div className="search-bar">
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
          <h2>Found a {result.type}:</h2>
          <pre>{JSON.stringify(result.data, null, 2)}</pre>
        </div>
      )}
    </div>
  );
}
