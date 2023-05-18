// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
import { getFirestore } from "firebase/firestore";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyDh842tV60OrGWTAke4_QFC7xj8nbJCjIk",
  authDomain: "e-commerce-2c290.firebaseapp.com",
  projectId: "e-commerce-2c290",
  storageBucket: "e-commerce-2c290.appspot.com",
  messagingSenderId: "128095352534",
  appId: "1:128095352534:web:e255fa8977cadf0cabfb77",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);
export const db = getFirestore(app);
