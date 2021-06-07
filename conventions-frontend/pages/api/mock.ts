export type Talk = {
  id: number;
  speaker: string;
  topic: string;
  description: string;
};
export type Convention = {
  id: number;
  location: string;
  date: string;
};
export const conventions: Array<Convention> = [
  {
    id: 1,
    location: "Copenhagen",
    date: new Date(2021, 10, 30).toLocaleDateString("en-US"),
  },
  {
    id: 2,
    location: "London",
    date: new Date(2021, 11, 4).toLocaleDateString("en-US"),
  },
];
export const talks: Array<Talk> = [
  {
    id: 1,
    speaker: "Dan Abramov",
    topic: "Beyond React 16",
    description:
      "React 16 was released several months ago. Even though this update was largely API-compatible, the rewritten internal engine included new long-requested features and opened the door for exciting future possibilities.",
  },
  {
    id: 2,
    speaker: "Simon Brown",
    topic: "Visualising software architecture with the C4 model",
    description:
      "In Simon Brown's talk at AOTB 2019 he explores the visual communication of software architecture based upon a decade of Simon’s experiences working with software development teams large and small across the globe.",
  },
];
