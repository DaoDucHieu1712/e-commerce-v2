import FeatureItem from "./FeatureItem";

const Feature = () => {
  return (
    <>
      <div className="container mx-auto my-4">
        <h1 className="text-xl font-medium mb-7">MOLOPOLY</h1>
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 overflow-x-hidden gap-4">
          <FeatureItem></FeatureItem>
          <FeatureItem></FeatureItem>
          <FeatureItem></FeatureItem>
          <FeatureItem></FeatureItem>
        </div>
      </div>
    </>
  );
};

export default Feature;
